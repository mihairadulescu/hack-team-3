# frozen_string_literal: true

module Assistant
  class Application
    route 'conversation' do |r|
      r.is do
        r.post do
          { result: :ok }
        end
      end
    end
  end
end
