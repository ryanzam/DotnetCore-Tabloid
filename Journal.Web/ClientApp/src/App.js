import React, { Component } from 'react';
import { Route } from 'react-router';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import CreateJournal from './components/CreateJournal';
import Journal from './components/Journal'
import Details from './components/Details';


import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
      <Layout>
        <Route exact path='/' component={Home} />
            <Route path='/journal' component={Journal} />
            <Route path='/details/:id' component={Details} />
            <Route path='/create' component={CreateJournal} />
      </Layout>
    );
  }
}
