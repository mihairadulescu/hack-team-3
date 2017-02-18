import React, {Component} from 'react';
import SearchBox from '../components/search-box';
import SearchResult from '../components/search-result';
export default class SearchResultPage extends Component {
    constructor(props) {
        super(props)
        this.state = {
            items: [
                {
                    title: "a new document in town",
                    content: "this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b> this is a nice <b>highlighted document</b>",
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                },
                {
                    title: "a new document in town",
                    content: "this is a nice <b>highlighted document</b>",
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                },
                {
                    title: "a new document in town",
                    content: "this is a nice <b>highlighted document</b>",
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                },
                {
                    title: "a new document in town",
                    content: "this is a nice <b>highlighted document</b>",
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                },
                {
                    title: "a new document in town",
                    content: "this is a nice <b>highlighted document</b>",
                    thumbnail: 'http://res.cloudinary.com/demo/image/upload/w_200,h_250,c_fill,e_sharpen/sample_document.docx.jpg'
                }
            ]
        }
    }

    componentDidMount = () => {
        console.log(this.props.router.params);
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
}