# frozen_string_literal: true
require 'dry/web/settings'
require 'dry-types'

module Assistant
  class Settings < Dry::Web::Settings
    module Types
      include Dry::Types.module

      module Required
        String = Types::Strict::String.constrained(min_size: 1)
      end
    end

    setting :solr_url, Types::Required::String
  end
end
