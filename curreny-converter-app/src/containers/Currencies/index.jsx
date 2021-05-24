import React, { useContext } from  'react';
import CurrencyContext from '../../Contexts/CurrencyContext';

export default function Currencies() {

    const currencies = useContext(CurrencyContext);

    const renderCurrencies = () => {
        return (
            currencies.map((curr, idx) => {
                return <li key={curr.isoCode}> { curr.isoCode } </li>
            })
        )
    }
    
    return (
        <>
        <p>Moedas Disponíveis: </p>
        <ul>
            { renderCurrencies() }
        </ul>
        <p> Todas as moedas usam o <strong>USD</strong> como lastro.</p>
        </>
    )
}