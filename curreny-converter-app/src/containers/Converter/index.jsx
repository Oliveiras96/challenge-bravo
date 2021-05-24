import React, { useContext, useState } from 'react';
import CurrencyContext from '../../Contexts/CurrencyContext';
import styles from './styles.module.css';

export default function Converter() {

    const currencies = useContext(CurrencyContext);
    const [origin, setOrigin] = useState("BRL");
    const [destiny, setDestiny] = useState("USD");
    const [amount, setAmount] = useState(10.00);

    const [result, setResult] = useState('');
    
    const handleOriginChange = (event) => {
        setOrigin(event.target.value);

    }
    
    const handleDestinyChange = (event) => {
        setDestiny(event.target.value);
    }

    const handleInputChange = (event) => {
        setAmount(event.target.value);
    }
    
    const handleClick = () => {
        const castedAmount = Number(amount);
        console.log('value of castedAmount:  ', castedAmount);

        if(typeof(castedAmount) === 'number' && !isNaN(castedAmount)) {

            const queryString = `?from=${origin}&to=${destiny}&amount=${castedAmount}`
            console.log(queryString);
    
            fetch(`https://localhost:5001/api/convert${queryString}`)
                .then(response => response.json())
                .then(response => setResult(response.message))
                .catch( err => console.log)
        } else {
            setResult('Entrada inválida');
        }

        // Used fetch API due to CORS issues...
        // api.get(`convert/${queryString}`, {
        //     params: {
        //         from: origin,
        //         to: destiny,
        //         amount: amount
        //     },
        //     headers: {
        //         'Access-Control-Allow-Origin': '*'
        //     }
        // })
        // .then(response => console.log )
    }

    // recieves an ISO Code to define thwe default value of the input
    const renderCurrencies = (which) => {
        return (
            currencies.map((item, idx) => {
                return <option value={ item.isoCode || origin } key={ item.id }> { item.isoCode || which } </option>
            })
        );
    }

    return (
        <>
            <p>Selecione a moeda de destino e a de origem e informa a quantia no campo valor.</p>

            <div className={styles.converterContainer}>
                <label htmlFor="">
                    Moeda de origem:
                    <select name="origin" onChange={handleOriginChange}>
                        {renderCurrencies('BRL')}
                    </select>
                </label>

                <label>
                    Moeda de destino:
                    <select name="destiny" onChange={handleDestinyChange}>
                        {renderCurrencies('USD')}
                    </select>
                </label>

                <label>
                    Valor:
                    <input type="text" placeholder={amount} onChange={handleInputChange}/>
                </label>

                <button onClick={handleClick}>Converter</button>

            </div>

            <p className={styles.result}>{result}</p>
        </>
    )
}