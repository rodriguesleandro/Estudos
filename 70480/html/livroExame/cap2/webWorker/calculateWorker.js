onmessage= function (e) {
			var work = 10000000;
			var i = 0;
			var a = new Array(work);
			var sum = 0;
			for (i = 0; i < work; i++) {
				a[i] = i * i;
				sum += i * i;
			}
			postMessage(sum);
}