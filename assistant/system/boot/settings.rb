# frozen_string_literal: true

Assistant::Container.finalize(:settings) do |container|
  require 'assistant/settings'
  container.register 'settings', Assistant::Settings.load(container.root, container.config.env)
end