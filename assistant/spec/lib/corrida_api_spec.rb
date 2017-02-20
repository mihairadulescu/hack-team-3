# frozen_string_literal: true
require 'spec_helper'
require 'corrida_api'
require 'json'

RSpec.describe CorridaApi do
  subject { CorridaApi.new('http://path.to.api').call }

  it 'will will get the data' do
    response_json = '[{"Data":"07 februarie 2017","Detalii":"Cumparare POS","IsMatched":false,"Debit":"111,26"},{"Data":"26 ianuarie 2017","Detalii":"Cumparare POS","IsMatched":false,"Debit":"120,00"}]'
    expect(Net::HTTP).to receive(:get).with(URI('http://path.to.api')).and_return(response_json)
    subject
  end
end