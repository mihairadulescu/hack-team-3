import React, {Component} from 'react';
import logo from './logo.png';
import './App.css';
import { Link} from 'react-router'

class App extends Component {
    render() {
        return (
            <div className="App">
                <div className="App-header">
                    <div className="logo-wrapper">
                        <img src={logo} className="App-logo" alt="logo"/>
                        <h2 className="App-logo-text">Corrida</h2>
                    </div>
                    <div className="menu-item">
                       <Link to='/' >
                           Home
                       </Link>
                    </div>
                    <div className="menu-item">
                        <Link to='/uploads' >
                            Uploads
                        </Link>

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
