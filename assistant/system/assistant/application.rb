# frozen_string_literal: true
require 'dry/web/roda/application'
require_relative 'container'

module Assistant
  class Application < Dry::Web::Roda::Application
    configure do |config|
      config.container = Container
      config.routes = 'web/routes'
    end

    opts[:root] = Pathname(__FILE__).join('../..').realpath.dirname

    plugin :json

    route do |r|
      r.multi_route

      r.root do
        "Welcome to corrida.assistant! Go ahead say 'Do I have missing invoices for January?'"
      end
    end

    load_routes!
  end
end
