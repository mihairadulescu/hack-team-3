# frozen_string_literal: true

module Assistant
  class Application
    route 'v1' do |r|
      r.on :conversations do
        r.post do
          params = JSON.parse(r.body.read)

          assistant_response = GoogleAssistant.respond_to(params, r.response) do |assistant|
            assistant.intent.main do
              assistant.ask(
                prompt: '<speak>Hi there! Say something, please.</speak>',
                no_input_prompt: [
                  "<speak>If you said something, I didn't hear you.</speak>",
                  '<speak>Did you say something?</speak>'
                ]
              )
            end

            assistant.intent.text do
              if assistant.conversation.state == 'invoices missing'
                if assistant.arguments[0].text_value.start_with?('yes')
                  assistant.tell('<speak>You are missing that one and the other one</speak>')
                else
                  assistant.tell('<speak>Have a wonderful day!</speak>')
                end
              else
                assistant.conversation.state = 'invoices missing'
                assistant.ask(
                  prompt: '<speak>Looks like you have 2 invoices missing. Should I tell witch ones?</speak>',
                  no_input_prompt: [
                    "<speak>If you said something, I didn't hear you.</speak>",
                    '<speak>Did you say something?</speak>'
                  ]
                )
              end
            end
          end

          assistant_response
        end
      end
    end
  end
end
