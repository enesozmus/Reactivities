import { Link } from "react-router-dom"
import { Container } from "semantic-ui-react"

export default function HomePage() {
    return (
        <Container style={{ marginTop: '7em' }}>
            <h1>Ana Sayfa</h1>
            <h3>Go to <Link to='/activities'>Aktiviteler</Link></h3>
        </Container>
    )
}