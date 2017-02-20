# frozen_string_literal: true
require 'dry/monads/either'

module Assistant
  module Conversations
    module Processors
      class ProcessWelcomeIntent
        include Dry::Monads::Either::Mixin

        def call(input)
          input[:main] = input[:assistant].ask(
            prompt: '<speak>Hi there! At your service.</speak>',
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