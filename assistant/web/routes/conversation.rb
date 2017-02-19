# frozen_string_literal: true

module Assistant
  class Application
    route 'v1' do |r|
      r.on :conversations do
        r.post do
          r.resolve('corrida_api') do |corrida_api|
            params = JSON.parse(r.body.read)

            assistant_response = GoogleAssistant.respond_to(params, r.response) do |assistant|
              assistant.intent.main do
                assistant.ask(
                  prompt: '<speak>Hi there! At your service.</speak>',
                  no_input_prompt: [
                    "<speak>If you said something, I didn't hear you.</speak>",
                    '<speak>Did you say something?</speak>'
                  ]
                )
              end

              assistant.intent.text do
                if assistant.conversation.state == 'missing_invoices'
                  if assistant.arguments[0].text_value.downcase.start_with?('yes')
                    missing_invoices = assistant.conversation.data['missing_invoices']
                    missing_invoices_ssml = missing_invoices.map do |missing_invoice|
                      "On <say-as interpet-as='date'>#{missing_invoice['Data']}</say-as> with #{missing_invoice['Debit']} <say-as interpet-as='characters'>RON</say-as>."
                    end.join
                    speak = '<speak> The missing invoices are: <break time="1s" />' + missing_invoices_ssml + '</speak>'
                    assistant.tell(speak)
                  else
                    assistant.tell('<speak>Have a wonderful day!</speak>')
                  end
                else
                  missing_invoices = corrida_api.call
                  if missing_invoices.empty?
                    assistant.tell('<speak>I looked and I looked and I could not find a missing invoice!</speak>')
                  else
                    assistant.conversation.state = 'missing_invoices'
                    assistant.conversation.data['missing_invoices'] = missing_invoices
                    assistant.ask(
                      prompt: "<speak>Looks like you have #{missing_invoices.count} invoices missing. Should I tell witch ones?</speak>",
                      no_input_prompt: [
                        "<speak>If you said something, I didn't hear you.</speak>",
                        '<speak>Did you say something?</speak>'
                      ]
                    )
                  end
                end
              end
            end

            assistant_response
          end
        end
      end
    end
  end
end
