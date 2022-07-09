import { Activity } from '../models/activity';
import agent from '../api/agent';
import { useEffect, useState } from 'react';
import NavBar from './NavBar';
import { Container, Header } from 'semantic-ui-react';
import ActivityDashboard from '../../features/activities/dashboard/ActivityDashboard';
import { v4 as uuid } from 'uuid';
import LoadingComponent from './LoadingComponent';


function App() {

  // useState()
  const [activities, setActivities] = useState<Activity[]>([]);

  const [selectedActivity, setSelectedActivity] = useState<Activity | undefined>(undefined);

  const [editMode, seteditMode] = useState(false);

  // loading indicator III
  const [loading, setLoading] = useState(true);

  // submit
  const [submitting, setSubmitting] = useState(false);



  // useEffect() => aktiviteleri listele
  useEffect(() => {
    agent.Activities.list().then(response => {
      // tarih gösterim ayarı
      let activities: Activity[] = [];
      response.forEach(activity => {
        activity.date = activity.date.split('T')[0];
        activities.push(activity);
      })
      //setActivities(response);
      setActivities(activities);
      // loading indicator IV
      setLoading(false);
    })
  }, [])


  // handle Selected / Cancel
  function hanldeSelectActivity(id: string) {
    setSelectedActivity(activities.find(x => x.id === id))
  }
  function hanldeCancelActivity() {
    setSelectedActivity(undefined)
  }


  // Formu Aç veya Kapat
  function handleFormOpen(id?: string) {
    id ? hanldeSelectActivity(id) : hanldeCancelActivity();
    seteditMode(true);
  }
  function handleFormClose() {
    seteditMode(false);
  }


  // Ekle veya Güncelle
  function handleCreateOrEditActivity(activity: Activity) {

    setSubmitting(true);

    if (activity.id)
    {
      agent.Activities.update(activity).then(() =>
      {
        setActivities([...activities.filter(x => x.id !== activity.id), activity])
        setSelectedActivity(activity);
        seteditMode(false);
        setSubmitting(false);
      })
    }
    else
    {
      activity.id = uuid();
      agent.Activities.create(activity).then(() =>
      {
        setActivities([...activities, activity])
        setSelectedActivity(activity);
        seteditMode(false);
        setSubmitting(false);
      })
    }
  }

  // Sil
  function handleDeleteActivity(id: string) {

    setSubmitting(true);
    agent.Activities.delete(id).then(() =>
    {
      setActivities([...activities.filter(x => x.id !== id)]);
      setSubmitting(false);
    })
  }

  // loading indicator V
  if (loading) return <LoadingComponent content='Uygulama yükleniyor...' />


  return (

    <>
      <NavBar openForm={handleFormOpen} />

      <Container style={{ marginTop: '7em' }}>

        <Header as='h2' icon="users" content='Reactivities' />

        <ActivityDashboard
          activities={activities}
          selectedActivity={selectedActivity}
          selectActivity={hanldeSelectActivity}
          cancelSelectActivity={hanldeCancelActivity}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createOrEditActivity={handleCreateOrEditActivity}
          deleteActivity={handleDeleteActivity}
          submitting ={submitting}
        />

      </Container>
    </>

  );
}

export default App;
