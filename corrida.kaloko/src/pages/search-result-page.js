import React, {Component} from 'react';
import SearchBox from '../components/search-box';
import SearchResult from '../components/search-result';
import  corridaApi from '../api/corridaAPI';
import './search-result-page.css';
export default class SearchResultPage extends Component {
    constructor(props) {
        super(props)
        this.state = {
            items: []
        }
    }

    componentDidMount = () => {
        this.searchByParams(this.props.router.params.search_phrase);

    }

    componentWillReceiveProps(nextProps){
        this.searchByParams(nextProps.router.params.search_phrase);
    }
    onSearch = (searchPhrase) => {
        this.props.router.push('/search/' + searchPhrase);
    }

    render() {
        return (<div>
            <SearchBox defaultValue ={this.props.router.params.search_phrase} className="search-result-box" onSearch={this.onSearch}/>
            <SearchResult items={this.state.items}/>
        </div>)
    }

    searchByParams = (search_phrase) =>  {
        if(search_phrase) {
            corridaApi.search(search_phrase).then((items) => {
                this.setState({items: items.data});
            });
        } else {
            corridaApi.search('').then((items) => {
                this.setState({items: items.data});
            });
        }
    }
}