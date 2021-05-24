import React from 'react';
import styles from './styles.module.css';

export default function Main() {

    return (
        <section className={styles.appSection}>
            <p>
                Esse App foi construído para consumir a API de conversão monetária
                desenvolvido por <a href="https://github.com/Oliveiras96">Oliveiras96</a> como parte de um projeto
                pessoal que visa aumentar minhas habilidades.

            </p>

            <p>
                A API em si foi desenvolvida em <strong>.NET Core</strong> e é baseada 
                no <strong>Desafio Bravo</strong>. Toda a documentação  detalhes sobre a API pode ser encontrada <a href="https://github.com/hurbcom/challenge-bravo">aqui</a>
            </p>
        </section>
    );
}