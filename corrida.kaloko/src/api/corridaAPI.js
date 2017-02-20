import  axios  from 'axios'
class CorridaAPI {
    search = (search_phrase) => {
        const url = "http://corrida12312312131.azurewebsites.net/api/search?keywords=";
        return axios.get(url + search_phrase);
    }

    delete = (id) => {
        const url = "http://corrida12312312131.azurewebsites.net/api/delete?guid="+id;
        return axios.get(url);
    }
}

const corridaApi = new CorridaAPI();
export default corridaApi;