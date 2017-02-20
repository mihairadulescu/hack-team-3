# frozen_string_literal: true
require 'spec_helper'
require 'app_helper'

RSpec.feature 'Conversations / Create', type: :request do
  describe 'welcome greeting' do
    def assistant_to_agent_welcome
      <<TEXT
      {
          "user": {
              "user_id": "Q815aAqJOGq68SV3MpHb/5A2wjy2u64n9zwTqhLB2Ek="
          },
          "conversation": {
              "conversation_id": "1487487416816",
              "type": 1
          },
          "inputs": [
              {
                  "intent": "assistant.intent.action.MAIN",
                  "raw_inputs": [
                      {
                          "input_type": 2,
                          "query": "talk to my accountant",
                          "annotation_sets": []
                      }
                  ],
                  "arguments": []
              }
          ]
      }
TEXT
    end

    background do
      post '/v2/conversations', assistant_to_agent_welcome
    end

    scenario 'welcome intent with expect user response' do
      expect(parsed_response['expect_user_response']).to be_truthy
    end

    scenario 'welcome intent will greet user' do
      expect(parsed_response['expected_inputs'][0]['input_prompt']['initial_prompts'][0]['ssml']).to eq '<speak>Hi there! At your service.</speak>'
    end

    scenario 'welcome intent will have no input prompts' do
      expect(parsed_response['expected_inputs'][0]['input_prompt']['no_input_prompts'][0]['ssml']).to eq "<speak>If you said something, I didn't hear you.</speak>"
      expect(parsed_response['expected_inputs'][0]['input_prompt']['no_input_prompts'][1]['ssml']).to eq '<speak>Did you say something?</speak>'
    end
  end

  describe 'missing invoices fulfilment' do
    def assistant_to_agent
      <<TEXT
      {
        "user": {
          "user_id": "Q815aAqJOGq68SV3MpHb/5A2wjy2u64n9zwTqhLB2Ek="
        },
        "conversation": {
          "conversation_id": "1487492585522",
          "type": 2,
          "conversation_token": { "state": null, "data": {} }
        },
        "inputs": [
          {
            "intent": "assistant.intent.action.TEXT",
            "raw_inputs": [
              {
                "input_type": 2,
                "query": "what invoices are missing",
                "annotation_sets": []
              }
            ],
            "arguments": [
              {
                "name": "text",
                "raw_text": "what invoices are missing",
                "text_value": "what invoices are missing"
              }
            ]
          }
        ]
      }
TEXT
    end

    background do
      post '/v2/conversations', assistant_to_agent
    end

    it 'will prompt for missing invoices' do
      expect(parsed_response['expect_user_response']).to be_truthy
    end
  end

  private

  def parsed_response
    JSON.parse(last_response.body)
  end
end