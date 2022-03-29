import React, { Component } from 'react'
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import CreateJournal from './components/CreateJournal';
import Journal from './components/Journal'
import Details from './components/Details'
import Login from './components/Auth/Login'
import useToken from './components/Auth/useToken';

import './custom.css'


function App() {
    const { token, setToken } = useToken();

    if (!token) {
        return <>
            <Login setToken={setToken} />
            <div className="text-center">
                <hr />
                <p>Or</p>
                <hr />
                <button className="w-50 btn btn-lg btn-primary" type="submit">Register</button>
            </div>
        </>
    }

    return (
        <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/journal' component={Journal} />
            <Route path='/details/:id' component={Details} />
            <Route path='/create' component={CreateJournal} />
            <Route path='/signout' component={Login} />
        </Layout>
    );
  }

export default App
