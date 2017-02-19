# frozen_string_literal: true
require 'dry/web/umbrella'
require_relative 'settings'

module Assistant
  class Container < Dry::Web::Umbrella
    configure do
      config.name = :assistant
      config.default_namespace = 'assistant'
      config.settings_loader = Assistant::Settings
      config.listeners = true

      config.auto_register = %w(
        lib/assistant
      )
    end

    load_paths! 'lib', 'system'

    def self.settings
      config.settings
    end
  end
end
