import React from 'react';
import './App.css';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import { NavigationBar } from './components/navigation-bar/NavigationBar';
import { Layout } from './components/layout/Layout';
import { DataPage } from './components/data/DataPage';
import { NotFound } from './components/not-found/NotFound';
import { NewCasePage } from './components/new/NewCasePage';


const App: React.FC = () => {
  return (
    <BrowserRouter>
      <NavigationBar/>
      <Layout>
        <Switch>
          <Route exact path='/' component={DataPage} />
          <Route exact path='/Data' component={DataPage} />
          <Route exact path='/New' component={NewCasePage} />
          <Route component={NotFound} />
        </Switch>
      </Layout>

    </BrowserRouter>
  );
}

export default App;
