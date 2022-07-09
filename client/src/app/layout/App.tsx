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


  // useEffect()
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


  // handle Form Open / Close
  function handleFormOpen(id?: string) {
    id ? hanldeSelectActivity(id) : hanldeCancelActivity();
    seteditMode(true);
  }
  function handleFormClose() {
    seteditMode(false);
  }


  // handle create or edit
  function handleCreateOrEditActivity(activity: Activity) {
    activity.id
      ? setActivities([...activities.filter(x => x.id !== activity.id), activity])
      : setActivities([...activities, { ...activity, id: uuid() }]);
    seteditMode(false);
    setSelectedActivity(activity);
  }

  // handle delete
  function handleDeleteActivity(id: string) {
    setActivities([...activities.filter(x => x.id !== id)])
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
        />

      </Container>
    </>

  );
}

export default App;
