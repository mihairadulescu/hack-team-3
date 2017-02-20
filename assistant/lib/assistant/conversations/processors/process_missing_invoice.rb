# frozen_string_literal: true
require 'dry/monads/either'
require 'assistant/import'

module Assistant
  module Conversations
    module Processors
      class ProcessMissingInvoice
        include Dry::Monads::Either::Mixin
        include Assistant::Import['corrida_api']

        def call(input)
          return if input[:missing_invoices].count.zero?

          input[:text] = input[:assistant].ask(
            prompt: "<speak>Looks like you have #{input[:missing_invoices].count} invoices missing. Should I tell witch ones?</speak>",
            no_input_prompt: [
              "<speak>If you said something, I didn't hear you.</speak>",
              '<speak>Did you say something?</speak>'
            ]
          )
          Dry::Monads::Right(input)
        end
      end
    end
  end
end