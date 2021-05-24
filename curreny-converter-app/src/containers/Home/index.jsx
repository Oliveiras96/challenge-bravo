import React from  'react';
import Converter from '../Converter';
import Currencies from '../Currencies';
import Main from '../../components/Main';
import styles from './styles.module.css';

import  { BrowserRouter, Switch, Route } from 'react-router-dom';
import NotFound from '../../components/NotFound';

export default function Home() {
    
    return (
       
        <section className={styles.appSection}>            
            <Switch>
                <Route path="/converter" component={Converter} />
                <Route path="/currencies" component={Currencies} /> 
                <Route path="/" component={Main} exact/>
                <Route component={NotFound} />
            </Switch>
        </section>
    );
}   