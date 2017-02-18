import React, {Component} from 'react';
import './search-box';
import './searchbox.css';
import {withRouter} from 'react-router';

export default class SearchBox extends Component {
    constructor(props) {
        super(props);
    }

    onSearch = (e) => {
        const searchPhrase = e.currentTarget.firstChild.value;
        this.props.onSearch(searchPhrase);
        e.preventDefault();
    }
    render() {
        return (<div className={this.props.className}>
            <form className="searchbox" onSubmit={this.onSearch}>
                <input type="text" placeholder="search for documents"/>
            </form>
        </div>);
    }
}