import React, {Component} from 'react';
import './search-result-item.css';

export default class SearchResultItem extends Component {
    constructor(props) {
        super(props);
    }

    render() {
        const {Title, Category, thumbnail, Snippet} = this.props.item;
        return (
            <div className="search-result-item">
                <div className="search-thumb">
                    <img src='https://assets.documentcloud.org/documents/2073555/pages/hhs-secretary-burwells-letter-to-gov-dayton-p1-normal.gif' />
                </div>
                <div className="search-description">
                    <h1>{Title}</h1>
                    {Snippet}
                    <div dangerouslySetInnerHTML ={ {__html: Category} } ></div>
                    <h2>{Category}</h2>
                </div>
            </div>
        )
    }
}