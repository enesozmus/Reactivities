import { ChangeEvent, useState } from "react";
import { Segment, Header, Form, Button } from "semantic-ui-react"
import { Activity } from "../../../app/models/activity";

interface Props {
    activity: Activity | undefined;
    closeForm: () => void;
    createOrEdit: (activity: Activity) => void;
    submitting: boolean;
}

export default function ActivityForm({ activity: selectedActivity, closeForm, createOrEdit, submitting }: Props) {

    // activity model
    const initialState = selectedActivity ?? {
        id: '',
        title: '',
        date: '',
        description: '',
        category: '',
        city: '',
        venue: ''
        //isCancelled: '',
    }

    const [activity, setActivity] = useState(initialState);

    // Submit

    function handleSubmit() {
        console.log(activity);
        createOrEdit(activity);
    }

    // Input Change
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setActivity({ ...activity, [name]: value })
    }

    return (
        <Segment clearing>

            <Header content='Activity Details' sub color='teal' />

            <Form onSubmit={handleSubmit} autoComplete='off'>

                <Form.Input placeholder='Başlık' value={activity.title} name='title' onChange={handleInputChange} />
                <Form.TextArea placeholder='Açıklama' value={activity.description} name='description' onChange={handleInputChange} />
                <Form.Input placeholder='Kategori' value={activity.category} name='category' onChange={handleInputChange} />
                <Form.Input type="date" placeholder='Tarih' value={activity.date} name='date' onChange={handleInputChange} />
                <Form.Input placeholder='Şehir' value={activity.city} name='city' onChange={handleInputChange} />
                <Form.Input placeholder='Mekan' value={activity.venue} name='venue' onChange={handleInputChange} />

                <Button
                    loading={submitting}
                    floated='right'
                    positive type="submit"
                    content='Kaydet' />
                <Button
                    onClick={closeForm}
                    floated='right'
                    type="button"
                    content='İptal Et' />

            </Form>

        </Segment>
    )
}