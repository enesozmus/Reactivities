import { useState, SyntheticEvent } from "react";
import { Link } from "react-router-dom"
import { Item, Button, Segment, Icon } from "semantic-ui-react"
import { Activity } from "../../../app/models/activity"
import { useStore } from "../../../app/stores/store";
import {format} from 'date-fns';

interface Props {
    activity: Activity
}

export default function ActivityListItem({ activity }: Props) {

    // mobx
    const { activityStore } = useStore();
    const { deleteActivity } = activityStore;

    // loading indicator ayarı
    const [target, setTarget] = useState('');

    function handleActivityDelete(e: SyntheticEvent<HTMLButtonElement>, id: string) {
        setTarget(e.currentTarget.name);
        deleteActivity(id);
    }

    return (
        <Segment.Group>

            <Segment>

                <Item.Group>
                    <Item>
                        <Item.Image size='tiny' circular src='/assets/user.png' />

                        <Item.Content>
                            <Item.Header as={Link} to={`/activities/${activity.id}`}>{activity.title}</Item.Header>
                        </Item.Content>

                        <Item.Description>
                            Hosted by User(soon)
                        </Item.Description>

                    </Item>
                </Item.Group>

            </Segment>

            <Segment>
                <span>
                    <Icon name='clock' /> {format(activity.date!, 'dd MMM yyyy h:mm aa')}
                    <Icon name='marker' /> {activity.venue}
                </span>
            </Segment>

            <Segment secondary>
                Katılımcılar buraya
            </Segment>

            <Segment clearing>
                <span>{activity.description}</span>
                <Button
                    as={Link} to={`/activities/${activity.id}`}
                    color='teal'
                    floated="right"
                    content="View"
                />
            </Segment>

        </Segment.Group>
    )
}