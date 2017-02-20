# frozen_string_literal: true
require 'assistant/transactions'

Assistant::Transactions.define do |t|
  t.define 'transactions.conversation' do
    step :process_welcome_intent, with: 'conversations.processors.process_welcome_intent'
    step :fetch_missing_invoices, with: 'conversations.operations.fetch_missing_invoices'
    step :process_missing_invoice, with: 'conversations.processors.process_missing_invoice'
  end
end
