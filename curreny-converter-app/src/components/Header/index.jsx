import React from 'react';
import styles from './styles.module.css';

import { Link } from 'react-router-dom';

function Header() {

    return (
        <header className={styles.header}>
            <span className={styles.appTitle}>
                <Link to="/"  className={styles.headerMenuItem}>
                    Currency Converter App 
                </Link>
            </span>
            <div className={styles.headerMenu}>
                <Link to="/converter" className={styles.headerMenuItem}>Converter</Link>
                <Link to="/currencies" className={styles.headerMenuItem}>Currencies </Link>
            </div>
        </header>
    );
}

export default Header;