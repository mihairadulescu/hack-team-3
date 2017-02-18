import React, {Component} from 'react';
import logo from './logo.png';
import './App.css';


class App extends Component {
    render() {
        return (
            <div className="App">
                <div className="App-header">
                    <div className="logo-wrapper">
                        <img src={logo} className="App-logo" alt="logo"/>
                        <h2 className="App-logo-text">Corrida</h2>
                    </div>
                </div>
                <div className="App-content">
                    {this.props.children}
                </div>
            </div>
        );
    }
}

export default App;
