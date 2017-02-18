import React, {Component} from 'react';
import './search-result-item.css';

export default class SearchResultItem extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const {title, content, thumbnail} = this.props.item;
        return (
            <div className="search-result-item">
                <div className="search-thumb">
                    <img src={thumbnail} />
                </div>
                <div className="search-description">
                    <h1>{title}</h1>
                    <h5>{content}</h5>
                </div>
            </div>
        )
    }
}