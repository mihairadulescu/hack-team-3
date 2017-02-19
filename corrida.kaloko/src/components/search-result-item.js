import React, {Component} from 'react';
import './search-result-item.css';

export default class SearchResultItem extends Component {
    constructor(props) {
        super(props);
    }

    renderContent(content) {
        return  content.map((page) => {
            return (<p>{page}</p>);
        })
    }
    render() {
        const {Title, Category, thumbnail, Content} = this.props.item;
        return (
            <div className="search-result-item">
                <div className="search-thumb">
                    <img src={thumbnail} />
                </div>
                <div className="search-description">
                    <h1>{Title}</h1>
                    {this.renderContent(Content)}
                </div>
            </div>
        )
    }
}