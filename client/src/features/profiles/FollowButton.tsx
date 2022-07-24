import { observer } from 'mobx-react-lite';
import React, { SyntheticEvent } from 'react';
import { Reveal, Button } from 'semantic-ui-react';
import { Profile } from '../../app/models/profile';
import { useStore } from '../../app/stores/store';

interface Props {
    profile: Profile;
}

export default observer(function FollowButton({ profile }: Props) {
    
    const {profileStore, userStore} = useStore();
    const {updateFollowing, loading} = profileStore;

    if (userStore.user?.userName === profile.userName) return null;

    function handleFollow(e: SyntheticEvent, username: string) {
        e.preventDefault();
        profile.following ? updateFollowing(username, false) : updateFollowing(username, true);
    }

    return (
        <Reveal animated='move'>
            <Reveal.Content visible style={{ width: '100%' }}>
                <Button 
                    fluid 
                    color='teal' 
                    content={profile.following ? 'Takip Ediliyor' : 'Takip Edilmiyor'} />
            </Reveal.Content>
            <Reveal.Content hidden style={{ width: '100%' }}>
                <Button
                    fluid
                    basic
                    color={profile.following ? 'red' : 'green'}
                    content={profile.following ? 'Takibi Bırak' : 'Takip Et'}
                    loading={loading}
                    onClick={(e) => handleFollow(e, profile.userName)}
                />
            </Reveal.Content>
        </Reveal>
    )
})