import { observer } from 'mobx-react-lite';
import { Segment, Grid, Item, Header, Statistic, Divider, Reveal, Button } from 'semantic-ui-react';
import { Profile } from '../../app/models/profile';

interface Props {
    profile: Profile;
}

export default observer(function ProfileHeader({ profile }: Props) {
    return (
        <Segment>
            <Grid>

                <Grid.Column width={12}>
                    <Item.Group>

                        <Item>
                            <Item.Image avatar size='small' src={profile.image || '/assets/user.png'} />
                            <Item.Content verticalAlign='middle'>
                                <Header as='h1'>
                                    {profile.firstName} {profile.lastName}
                                </Header>
                            </Item.Content>
                        </Item>

                    </Item.Group>
                </Grid.Column>

                <Grid.Column width={4}>

                    <Statistic.Group widths={2}>
                        <Statistic label='Takip edenler' value='5' />
                        <Statistic label='Takip ediyor' value='42' />
                    </Statistic.Group>

                    <Divider />

                    <Reveal animated='move'>
                        <Reveal.Content visible style={{ width: '100%' }}>
                            <Button fluid color='teal' content='Takip ediyor' />
                        </Reveal.Content>
                        <Reveal.Content hidden style={{ width: '100%' }}>
                            <Button
                                fluid
                                basic
                                color={true ? 'red' : 'green'}
                                content={true ? 'Takibi Bırak' : 'Takip Et'}
                            />
                        </Reveal.Content>
                    </Reveal>

                </Grid.Column>

            </Grid>
        </Segment>
    )
})