import React, {Component} from 'react';
import SearchBox from '../components/search-box';
import SearchResult from '../components/search-result';
import  corridaApi from '../api/corridaAPI';

export default class SearchResultPage extends Component {
    constructor(props) {
        super(props)
        this.state = {
            items: [
                {
                    Title: "a new document in town",
                    Content: ["this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b>"],
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                },
                {
                    Title: "a new document in town",
                    Content: ["this is a nice <b>highlighted document</b>"],
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                },
                {
                    Title: "a new document in town",
                    Content: ["this is a nice <b>highlighted document</b>"],
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                }
            ]
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
            <SearchBox className="" onSearch={this.onSearch}/>
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