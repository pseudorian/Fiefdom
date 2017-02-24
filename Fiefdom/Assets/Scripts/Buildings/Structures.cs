using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Structures
{
    public enum BuildPhase
    {
        blank,
        General,
        Design,
        Carpentry,
        Masonry,
        Thatching,
        Complete
    }

    public enum Priority
    {
        Low, Normal, High
    }

    public enum ProjectType
    {
        blank, Build, Farm
    }

    public class Project
    {
        //References
        private GameManager gm;

        //Variables
        public Transform target;
        public ProjectType type;
        public Priority priority { get; private set; }
        public List<People.Task> tasks;

        public Project()
        {
            target = null;
            type = ProjectType.blank;
            priority = Priority.Normal;
            tasks = null;
        }

        public Project(Transform target, ProjectType type)
        {
            this.target = target;
            this.type = type;
            priority = Priority.Normal;
            tasks = new List<People.Task>();
        }

        public void Clear()
        {
            target = null;
            type = ProjectType.blank;
            priority = Priority.Normal;
            tasks.Clear();
        }

        public void ChangePriority(Priority newPriority)
        {
            gm = GameObject.Find("GameManager").GetComponent<GameManager>();
            gm.ChangeProjectPriority(this, newPriority);
            priority = newPriority;
        }
    }
}
