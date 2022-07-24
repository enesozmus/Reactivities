import { observer } from 'mobx-react-lite';
import { Segment, Grid, Item, Header, Statistic, Divider } from 'semantic-ui-react';
import { Profile } from '../../app/models/profile';
import FollowButton from './FollowButton';

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
                        <Statistic label='Takip edenler' value={profile.followersCount} />
                        <Statistic label='Takip ediyor' value={profile.followingCount} />
                    </Statistic.Group>

                    <Divider />

                    <FollowButton profile={profile} />

                </Grid.Column>

            </Grid>
        </Segment>
    )
})