import React from 'react';
import { Link } from 'react-router-dom';
import { Button, Header, Icon, Segment } from 'semantic-ui-react';

export default function NotFound() {
    return (
        <Segment placeholder>
            <Header icon>
                <Icon name='search' />
                Oops - Her yere baktık ve aradığınızı bulamadık.
            </Header>
            <Segment.Inline>
                <Button as={Link} to='/activities' primary>
                    Etkinlikler Sayfasına Geri Dönün
                </Button>
            </Segment.Inline>
        </Segment>
    )
}