import { observer } from 'mobx-react-lite';
import React from 'react';
import { Link, NavLink } from 'react-router-dom';
import { Button, Container, Menu, Image, Dropdown } from 'semantic-ui-react';
import { useStore } from '../stores/store';

export default observer(function NavBar() {

    const { userStore: { user, logout } } = useStore();

    return (
        <Menu inverted fixed='top'>
            <Container>
                <Menu.Item as={NavLink} exact to='/' header>
                    <img src='/assets/logo.png' alt='logo' style={{ marginRight: '10px' }} />
                    Reactivities
                </Menu.Item>
                <Menu.Item as={NavLink} to='/activities' name='Etkinlikler' />
                <Menu.Item as={NavLink} to='/errors' name='Hata Yönetim Paneli' />
                <Menu.Item>
                    <Button as={NavLink} to='/createActivity' positive content='Etkinlik Ekle' />
                </Menu.Item>
                <Menu.Item position='right'>

                    <Image src={user?.image || '/assets/user.png'} avatar spaced='right' />

                    <Dropdown pointing='top left' text={user?.userName}>
                        <Dropdown.Menu>
                            <Dropdown.Item as={Link} to={`/profile/${user?.userName}`}
                                text='Profilim' icon='user' />
                            <Dropdown.Item onClick={logout} text='Çıkış Yap' icon='power' />
                        </Dropdown.Menu>
                        
                    </Dropdown>
                </Menu.Item>
            </Container>
        </Menu>
    )
})