import styles from './styles.module.css';

export default function NotFound() {
    return (
        <div className={styles.container}>
            <span>
                <img src="/error-404.png" alt="Error 404" />
            </span>
            <span>
                Not Found!
            </span>
        </div>
    )
}