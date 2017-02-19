import React, {Component} from 'react';
import ReactDOM from 'react-dom';
import './main-page.css';
import {withRouter} from 'react-router';
import DropzoneComponent from 'react-dropzone-component';
import './uploads-page.css';

class UploadsPage extends Component {
    constructor(props) {
        super(props)
    }

    render() {
        const url = "http://localhost:3986//api/document";
        var componentConfig = { postUrl: url };
        var djsConfig = { autoProcessQueue: true }
        var eventHandlers = { addedfile: (file) => console.log(file) }

        return (<div className='uploads-page-wrapper'>
            <DropzoneComponent config={componentConfig}
                               eventHandlers={eventHandlers}
                               djsConfig={djsConfig} />
        </div>)
    }
}

export default withRouter(UploadsPage);