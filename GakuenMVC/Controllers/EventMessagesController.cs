using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DLLGakuen;
using DLLGakuen.Entity;

namespace GakuenMVC.Controllers
{
    public class EventMessagesController : Controller
    {
        private readonly IServiceGateway<EventMessage> _eventMessageServiceGateway = new DllFacade().GetEventMessageServiceGateway();
        private readonly IServiceGateway<ImageToHost> _imageToHostServiceGateway = new DllFacade().GetImageTohostServiceGateway();
        private readonly IServiceGateway<VideoToHost> _videoToHostServiceGateway = new DllFacade().GetVideoToHostServiceGateway();

        // GET: EventMessages
        public ActionResult Index()
        {
            return View(_eventMessageServiceGateway.Read());
        }

        // GET: EventMessages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMessage eventMessage = _eventMessageServiceGateway.Read(id.Value);
            if (eventMessage == null)
            {
                return HttpNotFound();
            }
            return View(eventMessage);
        }

        // GET: EventMessages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventMessages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] EventMessage eventMessage, [Bind(Include = "Id, ImagePath")] ImageToHost imageToHost, [Bind(Include = "Id,VideoPath")] VideoToHost videoToHost
            )
        {
            if (ModelState.IsValid)
            {
                var message = eventMessage;
               
                    message.ImageToHost = imageToHost;    
                    message.VideoToHost = videoToHost;
                
                _eventMessageServiceGateway.Create(message);
                return RedirectToAction("Index");
            }

            return View(eventMessage);
        }

        // GET: EventMessages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMessage eventMessage = _eventMessageServiceGateway.Read(id.Value);
            if (eventMessage == null)
            {
                return HttpNotFound();
            }
            return View(eventMessage);
        }

        // POST: EventMessages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body,ImageToHost,VideoToHost")] EventMessage eventMessage)
        {
            if (ModelState.IsValid)
            {
                _eventMessageServiceGateway.Update(eventMessage);
                _imageToHostServiceGateway.Update(eventMessage.ImageToHost);
                _videoToHostServiceGateway.Update(eventMessage.VideoToHost);

                return RedirectToAction("Index");
            }
            return View(eventMessage);
        }

        // GET: EventMessages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventMessage eventMessage = _eventMessageServiceGateway.Read(id.Value);
            if (eventMessage == null)
            {
                return HttpNotFound();
            }
            return View(eventMessage);
        }

        // POST: EventMessages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var eventMessage = _eventMessageServiceGateway.Read(id);
            _eventMessageServiceGateway.Delete(id);
            if (eventMessage.ImageToHost != null)
            {
                _imageToHostServiceGateway.Delete(eventMessage.ImageToHost.Id);
            }
            if (eventMessage.VideoToHost != null)
            {
                _videoToHostServiceGateway.Delete(eventMessage.VideoToHost.Id);
            }
            return RedirectToAction("Index");
        }

        
    }
}
