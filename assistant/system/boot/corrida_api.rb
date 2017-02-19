# frozen_string_literal: true

Assistant::Container.finalize(:corrida_api) do |_container|
  use :settings

  require 'corrida_api'

  container.register :corrida_api, CorridaApi.new(settings.corrida_api_url)
end