import React, {Component} from 'react';
import './main-page.css';
import {withRouter} from 'react-router';
import SearchBox from '../components/search-box';
class MainPage extends Component {
    constructor(props) {
        super(props)
    }
    onSearch = (searchPhrase) => {
        this.props.router.push('/search/' + searchPhrase);
    }

    render() {
        return (<div className='main-search-wrapper'>
            <SearchBox className="main-searchbox" onSearch = {this.onSearch}/>
        </div>)
    }
}

export default withRouter(MainPage);