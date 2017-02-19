# frozen_string_literal: true
require 'net/http'

class CorridaApi
  attr_reader :api_url

  def initialize(api_url)
    @api_url = api_url
  end

  def call
    uri = URI(api_url)
    response = Net::HTTP.get(uri)
    JSON.parse(response)
  end
end