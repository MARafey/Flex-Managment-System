// Get references to the form and table elements
const form = document.querySelector('form');
const table = document.querySelector('#report-table');

// Add event listener to the form to generate the report when submitted
form.addEventListener('submit', (event) => {
    // Prevent the form from submitting and reloading the page
    event.preventDefault();

    // Get the selected course and report type from the form
    const course = form.elements['course-select'].value;
    const reportType = form.elements['report-type'].value;

    // Generate the report based on the selected report type
    switch (reportType) {
        case 'students-section':
            generateStudentsSectionReport(course);
            break;
        // Add cases for other report types here
    }
});

// Function to generate the Students Section Report
function generateStudentsSectionReport(course) {
    // Set the table header row
    // Get references to the form and table elements
    const form = document.querySelector('form');
    const table = document.querySelector('#report-table');

    // Add event listener to the form to generate the report when submitted
    form.addEventListener('submit', (event) => {
        // Prevent the form from submitting and reloading the page
        event.preventDefault();

        // Get the selected course and report type from the form
        const course = form.elements['course-select'].value;
        const reportType = form.elements['report-type'].value;

        // Generate the report based on the selected report type
        switch (reportType) {
            case 'students-section':
                generateStudentsSectionReport(course);
                break;
            case 'offered-courses':
                generateOfferedCoursesReport(course);
                break;
            case 'course-allocation':
                generateCourseAllocationReport(course);
                break;
        }
    });

    // Function to generate the Students Section Report
    function generateStudentsSectionReport(course) {
        // Set the table header row
        table.innerHTML = `
    <thead>
      <tr>
        <th>Section Name</th>
        <th>Roll Number</th>
      </tr>
    </thead>
    <tbody>
    </tbody>
  `;

        // Get the data for the report (in this example, we'll use sample data)
        const reportData = [
            { sectionName: 'A', rollNumber: 101 },
            { sectionName: 'A', rollNumber: 102 },
            { sectionName: 'B', rollNumber: 201 },
            { sectionName: 'B', rollNumber: 202 },
            { sectionName: 'B', rollNumber: 203 },
        ];

        // Generate the table rows for the report data
        const tableBody = table.querySelector('tbody');
        reportData.forEach((data) => {
            const row = document.createElement('tr');
            row.innerHTML = `
      <td>${data.sectionName}</td>
      <td>${data.rollNumber}</td>
    `;
            tableBody.appendChild(row);
        });
    }

    // Function to generate the Offered Courses Report
    function generateOfferedCoursesReport(course) {
        // Set the table header row
        table.innerHTML = `
    <thead>
      <tr>
        <th>Course ID</th>
        <th>Course Name</th>
        <th>Credit Hours</th>
      </tr>
    </thead>
    <tbody>
    </tbody>
  `;

        // Get the data for the report (in this example, we'll use sample data)
        const reportData = [
            { courseID: 'MATH101', courseName: 'Calculus I', creditHours: 3 },
            { courseID: 'HIST101', courseName: 'World History I', creditHours: 3 },
            { courseID: 'ENGL101', courseName: 'Composition I', creditHours: 3 },
        ];

        // Generate the table rows for the report data
        const tableBody = table.querySelector('tbody');
        reportData.forEach((data) => {
            const row = document.createElement('tr');
            row.innerHTML = `
      <td>${data.courseID}</td>
      <td>${data.courseName}</td>
      <td>${data.creditHours}</td>
    `;
            tableBody.appendChild(row);
        });
    }

    // Function to generate the Course Allocation Report
    // Function to generate the Course Allocation Report
    function generateCourseAllocationReport(course) {
        // Set the table header row
        table.innerHTML = `
    <thead>
      <tr>
        <th>Course ID</th>
        <th>Course Name</th>
        <th>Credit Hours</th>
        <th>Teachers</th>
        <th>Course Coordinator</th>
      </tr>
    </thead>
    <tbody>
    </tbody>
  `;

        // Get the data for the report (in this example, we'll use sample data)
        const reportData = [
            {
                courseID: 'MATH101',
                courseName: 'Calculus I',
                creditHours: 3,
                teachers: ['John Smith', 'Jane Doe'],
                courseCoordinator: 'David Johnson',
            },
            {
                courseID: 'HIST101',
                courseName: 'World History I',
                creditHours: 3,
                teachers: ['Mary Brown'],
                courseCoordinator: 'Robert Davis',
            },
            {
                courseID: 'ENGL101',
                courseName: 'Composition I',
                creditHours: 3,
                teachers: ['Jessica Lee', 'Michael Chen'],
                courseCoordinator: 'Emily Kim',
            },
        ];

        // Generate the table rows for the report data
        const tableBody = table.querySelector('tbody');
        reportData.forEach((data) => {
            const row = document.createElement('tr');
            const teachers = data.teachers.join(', ');
            row.innerHTML = `
      <td>${data.courseID}</td>
      <td>${data.courseName}</td>
      <td>${data.creditHours}</td>
      <td>${teachers}</td>
      <td>${data.courseCoordinator}</td>
    `;
            tableBody.appendChild(row);
        });
    }
