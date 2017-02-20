# frozen_string_literal: true
require 'dry/monads/either'
require 'assistant/import'

module Assistant
  module Conversations
    module Operations
      class FetchMissingInvoices
        include Assistant::Import['corrida_api']

        def call(input)
          input[:missing_invoices] = corrida_api.call
          Dry::Monads::Right(input)
        end
      end
    end
  end
end
