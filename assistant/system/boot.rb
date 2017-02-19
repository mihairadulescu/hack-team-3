# frozen_string_literal: true
require 'byebug' if ENV['RACK_ENV'] == 'development'
require 'pry' if ENV['RACK_ENV'] == 'development'

require_relative 'assistant/container'

Assistant::Container.finalize!

require 'assistant/application'

require 'assistant/transactions'
Assistant::Container.require 'transactions/**/*.rb'
