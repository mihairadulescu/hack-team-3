import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import './index.css';
import { Router, Route, IndexRoute } from 'react-router'
import MainPage from './pages/main-page'
import SearchResultPage from './pages/search-result-page';
import UploadsPage from './pages/uploads-page'

import { browserHistory } from 'react-router'

console.log( document.getElementById('root'))
ReactDOM.render((
    <Router history={browserHistory}>
        <Route path="/" component={App}>
            <IndexRoute component={MainPage} />
            <Route path="search/:search_phrase" component={SearchResultPage} />
            <Route path="search" component={SearchResultPage} />
            <Route path="uploads" component={UploadsPage} />
        </Route>
    </Router>
), document.getElementById('root'));