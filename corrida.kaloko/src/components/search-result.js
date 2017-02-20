import React, {Component} from 'react';
import SearchResultItem from './search-result-item';


export default class SearchResult extends Component {
    constructor(props) {
        super(props);
    }

    renderItems = (items) => {
       return items.map((item) => (<SearchResultItem wasDeleted={this.props.wasDeleted} item={item}/>))
    }

    render() {
        return (
            <div>
                {this.renderItems(this.props.items)}
            </div>
        )
    }
}