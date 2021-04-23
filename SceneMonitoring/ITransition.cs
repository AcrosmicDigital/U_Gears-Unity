using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U.Universal
{
    public interface ITransition
    {

        void TransitionSetUp();
        void TransitionSetUpProgress(float percentage);
        void TransitionSetUpReady();
        void TransitionLoadProgres(float percentage);
        void TransitionTearDown();
        void TransitionTearDownProgress(float percentage);
        void TransitionTearDownReady();

    }
}
