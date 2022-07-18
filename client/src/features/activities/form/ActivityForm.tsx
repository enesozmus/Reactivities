import { observer } from 'mobx-react-lite';
import React, { useEffect, useState } from 'react';
import { Link, useHistory, useParams } from 'react-router-dom';
import { Button, Header, Segment } from 'semantic-ui-react';
import LoadingComponent from '../../../app/layout/LoadingComponent';
import { useStore } from '../../../app/stores/store';
import { v4 as uuid } from 'uuid';
import { Formik, Form } from 'formik';
import * as Yup from 'yup';
import MyTextInput from '../../../app/common/form/MyTextInput';
import MyTextArea from '../../../app/common/form/MyTextArea';
import MySelectInput from '../../../app/common/form/MySelectInput';
import { categoryOptions } from '../../../app/common/options/categoryOptions';
import MyDateInput from '../../../app/common/form/MyDateInput';
import { Activity, ActivityFormValues } from '../../../app/models/activity';

export default observer(function ActivityForm() {

    // v5 history
    const history = useHistory();

    // mobx
    const { activityStore } = useStore();
    const { createActivity, updateActivity, loadActivity, loadingInitial } = activityStore;

    // id | useParams
    const { id } = useParams<{ id: string }>();

    // model | etkinlik
    const [activity, setActivity] = useState<ActivityFormValues>(new ActivityFormValues());

    // doğrulama kuralları
    const validationSchema = Yup.object({
        title: Yup.string().required('The activity title is required'),
        description: Yup.string().required('The activity description is required'),
        category: Yup.string().required(),
        date: Yup.string().required('Date is required').nullable(),
        venue: Yup.string().required(),
        city: Yup.string().required(),
    })

    useEffect(() => {
        if (id) loadActivity(id).then(activity => setActivity(new ActivityFormValues(activity)))
    }, [id, loadActivity]);

    // Form Açıldığında Yenisini Ekle ya da var olanı Güncelle
    function handleFormSubmit(activity: ActivityFormValues) {
        if (!activity.id) {
            let newActivity = { ...activity, id: uuid() };
            createActivity(newActivity).then(() => history.push(`/activities/${newActivity.id}`))
        }
        else {
            updateActivity(activity).then(() => history.push(`/activities/${activity.id}`))
        }
    }

    if (loadingInitial) return <LoadingComponent content='Aktivite yükleniyor...' />

    return (
        <Segment clearing>
            <Header content='Etkinlik Detayları' sub color='teal' />
            <Formik
                validationSchema={validationSchema}
                enableReinitialize
                initialValues={activity}
                onSubmit={values => handleFormSubmit(values)}>
                {({ handleSubmit, isValid, isSubmitting, dirty }) => (
                    <Form className='ui form' onSubmit={handleSubmit} autoComplete='off'>
                        <MyTextInput name='title' placeholder='Başlık' />
                        <MyTextArea rows={3} placeholder='Açıklama' name='description' />
                        <MySelectInput options={categoryOptions} placeholder='Kategori' name='category' />
                        <MyDateInput
                            placeholderText='Tarih'
                            name='date'
                            showTimeSelect
                            timeCaption='time'
                            dateFormat='MMMM d, yyyy h:mm aa'
                        />
                        <Header content='Location Details' sub color='teal' />
                        <MyTextInput placeholder='Şehir' name='city' />
                        <MyTextInput placeholder='Mekan' name='venue' />

                        <Button
                            disabled={isSubmitting || !dirty || !isValid}
                            loading={isSubmitting}
                            floated='right'
                            positive type='submit'
                            content='Kaydet'
                        />

                        <Button
                            as={Link} to='/activities'
                            floated='right'
                            type='button'
                            content='İptal Et'
                        />

                    </Form>
                )}
            </Formik>

        </Segment>
    )
})