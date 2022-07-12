import { NavLink } from "react-router-dom";
import { Container, Menu, Button } from "semantic-ui-react";

export default function NavBar() {

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} to='/' exact header>
                    <img src="/assets/logo.png" alt="logo" style={{ marginRight: '7em' }} />
                    Ana Sayfa
                </Menu.Item>

                <Menu.Item as={NavLink} to='/activities' name="Aktiviteler" />

                <Menu.Item>
                    <Button as={NavLink} to='/createActivity' positive content='Aktivite Ekle'></Button>
                </Menu.Item>

            </Container>
        </Menu>
    )

}