﻿using System.Threading;
using System.Threading.Tasks;
using NewLife;
using NewLife.Log;
using StarGateway.Proxy;

namespace StarGateway
{
    class MyService : IHostedService
    {
        private HttpReverseProxy _proxy;
        private HttpReverseProxy _proxy2;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            var set = Setting.Current;

            var server = new HttpReverseProxy
            {
                Port = 8080,
                RemoteServer = "http://star.newlifex.com",

                Log = XTrace.Log,
            };

            if (set.Debug) server.SessionLog = XTrace.Log;

            server.Start();

            _proxy = server;

            var server2 = new HttpReverseProxy
            {
                Port = 80,
                RemoteServer = "http://star.newlifex.com",

                Log = XTrace.Log,
            };

            if (set.Debug) server2.SessionLog = XTrace.Log;

            server2.Start();

            _proxy2 = server2;

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _proxy.TryDispose();
            _proxy2.TryDispose();

            return Task.CompletedTask;
        }
    }
}
