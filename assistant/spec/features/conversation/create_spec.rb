# frozen_string_literal: true
require 'spec_helper'
require 'app_helper'

RSpec.feature 'Conversation / Create', type: :request do
  scenario 'it works' do
    post '/conversation'

    expect(last_response).to be_ok
  end
end